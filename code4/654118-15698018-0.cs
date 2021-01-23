    static void Main(string[] args)
    {
            CrmService.CrmService svc = new CrmService.CrmService();
            svc.CrmAuthenticationTokenValue = GetToken();
            svc.UseDefaultCredentials = true;
            #region 1 - Retrieve users in team
            RetrieveMembersTeamRequest teamMembersReq = new RetrieveMembersTeamRequest()
            {
                EntityId = new Guid("D56E0E83-2198-E211-9900-080027BBBE99"), //You'll need the team GUID
                ReturnDynamicEntities = true
            };
            ColumnSet teamMembersReqColumnSet = new ColumnSet();
            teamMembersReqColumnSet.Attributes = new string[] { "systemuserid", "domainname" };
            teamMembersReq.MemberColumnSet = teamMembersReqColumnSet; //Don't use: teamMembersReq.MemberColumnSet = new AllColumns()
            
            List<Guid> userIdList = new List<Guid>();
            RetrieveMembersTeamResponse teamMembersResp = svc.Execute(teamMembersReq) as RetrieveMembersTeamResponse;
            if (teamMembersResp != null)
            {
                BusinessEntity[] usersInTeamAsBusinessEntity = teamMembersResp.BusinessEntityCollection.BusinessEntities;
                List<DynamicEntity> usersInTeamAsDynEntity = usersInTeamAsBusinessEntity.Select(be => be as DynamicEntity).ToList(); //BusinessEntity not too useful, cast to DynamicEntity
                foreach (DynamicEntity de in usersInTeamAsDynEntity)
                {
                    Property userIdProp = de.Properties.Where(p => p.Name == "systemuserid").FirstOrDefault();
                    Property domainNameProp = de.Properties.Where(p => p.Name == "domainname").FirstOrDefault();
                    if (userIdProp != null)
                    {
                        KeyProperty userIdKeyProp = userIdProp as KeyProperty; //Because it is the unique identifier of the entity
                        userIdList.Add(userIdKeyProp.Value.Value); //Chuck in a list for use later
                        Console.Write("Key: " + userIdKeyProp.Value.Value.ToString());
                    }
                    if (domainNameProp != null)
                    {
                        StringProperty domainNameStringProp = domainNameProp as StringProperty; //Because its data type is varchar
                        Console.Write("| Domain Name: " + domainNameStringProp.Value);
                    }
                    Console.WriteLine();
                }
            }
            #endregion
            /*
             * For this example I have created a dummy entity called new_availablehours that is in a 1:N relationship with use (i.e. 1 user, many new_available hours). 
             * The test attributes are :
             *      - the relationship attribute is called new_userid...this obviously links across to the GUID from systemuser
             *      - there is an int data type attribute called new_hours
             *      - there is a datetime attribute called new_availabilityday
             */
            #region Retrieve From 1:N
            RetrieveMultipleRequest req = new RetrieveMultipleRequest();
            req.ReturnDynamicEntities = true; //Because we love DynamicEntity
            //QueryExpression says what entity to retrieve from, what columns we want back and what criteria we use for selection
            QueryExpression qe = new QueryExpression();
            qe.EntityName = "new_availablehours"; //the entity on the many side of the 1:N which we want to get data from
            qe.ColumnSet = new AllColumns(); //Don't do this in real life, limit it like we did when retrieving team members
            /*
             * In this case we have 1 x Filter Expression which combines multiple Condition Operators
             * Condition Operators are evaluated together using the FilterExpression object's FilterOperator property (which is either AND or OR)
             * 
             * So if we use AND all conditions need to be true and if we use OR then at least one of the conditions provided needs to be true
             * 
             */
            FilterExpression fe = new FilterExpression();
            fe.FilterOperator = LogicalOperator.And;
            ConditionExpression userCondition = new ConditionExpression();
            userCondition.AttributeName = "new_userid"; //The attribute of qe.EntityName which we want to test against
            userCondition.Operator = ConditionOperator.In; //Because we got a list of users previously, the appropriate check is to get records where new_userid is in the list of valid ones we generated earlier
            userCondition.Values = userIdList.Select(s => s.ToString()).ToArray(); //Flip the GUID's to strings (seems that CRM likes that) then set them as the values we want to evaulate
            //OK - so now we have this userCondition where valid records have their new_userid value in a collection of ID's we specify
            ConditionExpression dateWeekBound = new ConditionExpression();
            dateWeekBound.AttributeName = "new_availabilityday";
            dateWeekBound.Operator = ConditionOperator.ThisWeek; //ConditionOperator has a whole bunch of convenience operators to deal with dates (e.g. this week, last X days etc) - check them out as they are very handy
            /*
             * As an aside, if we didn't want to use the convenience operator (or if none was available) we would have to create a ConditionExpression like:
             * 
             * ConditionExpression dateLowerBound = new ConditionExpression();
             * dateLowerBound.AttributeName = "new_availabilityday";
             * dateLowerBound.Operator = ConditionOperator.OnOrAfter;
             * dateLowerBound.Values = new object[] { <Your DateTime object here> };
             * 
             * And a corresponding one for the upper bound using ConditionOperator.OnOrBefore
             * 
             * Another alternative is to use ConditionOperator.Between. This is flexible for any sort of data, but the format of the Values array will be something like:
             *      ce.Values = new object[] { <lower bound>, <upper bound> };
             */
            fe.Conditions = new ConditionExpression[] { userCondition, dateWeekBound }; //Add the conditions to the filter
            qe.Criteria = fe; //Tell the query what our filters are
            req.Query = qe; //Tell the request the query we want to use
            RetrieveMultipleResponse resp = svc.Execute(req) as RetrieveMultipleResponse;
            if (resp != null)
            {
                BusinessEntity[] rawResults = resp.BusinessEntityCollection.BusinessEntities;
                List<DynamicEntity> castedResults = rawResults.Select(r => r as DynamicEntity).ToList();
                foreach (DynamicEntity result in castedResults)
                {
                    Property user = result.Properties.Where(p => p.Name == "new_userid").FirstOrDefault();
                    Property hours = result.Properties.Where(p => p.Name == "new_hours").FirstOrDefault();
                    if (user != null)
                    {
                        LookupProperty relationshipProperty = user as LookupProperty; //Important - the relationship attribute casts to a LookupProperty
                        Console.Write(relationshipProperty.Value.Value.ToString() + ", ");
                    }
                    if (hours != null)
                    {
                        CrmNumberProperty hoursAsCrmNumber = hours as CrmNumberProperty; //We also have CrmFloatProperty, CrmDecimalProperty etc if the attribute was of those data types
                        Console.Write(hoursAsCrmNumber.Value.Value);
                    }
                    Console.WriteLine();
                }
            }
            #endregion
            Console.ReadLine();
        }
        static CrmAuthenticationToken GetToken()
        {
            CrmAuthenticationToken token = new CrmAuthenticationToken();
            token.AuthenticationType = 0; //Active Directory
            token.OrganizationName = "DevCRM";
            return token;
        }
