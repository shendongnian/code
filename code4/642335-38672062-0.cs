    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var value = (Data)existingValue;
                if (value == null)
                {
                    value = new Data();
                    value.SurveyQuestions = new List<SurveyQuestion>();
                    value.SurveyUrls = new List<SurveyUrl>();
                    value.SurveyGeoDatas = new List<SurveyGeoData>();
                    value.SurveyVariables = new List<SurveyVariable>();
                    value.SurveyVariableShowns = new List<SurveyVariableShown>();
                    value.SurveyQuestionHiddens = new List<SurveyQuestionHidden>();
                    value.SurveyQuestionOptions = new List<SurveyQuestionOption>();
                    value.SurveyQuestionMulties = new List<SurveyQuestionMulti>();
                }
                // Skip opening {
                reader.Read();
                while (reader.TokenType == JsonToken.PropertyName)
                {
                    var name = reader.Value.ToString();
                    reader.Read();
                    // Here is where you do your magic
                    string input = name;
                    //[question(1)]
                    //[question(11)]
                    //[question(111)]
                    //[question(1234)]
                    //[question(12345)]
                    //[url(12345)]
                    //[variable(12345)]
                    //SINGLE ANSWER
                    Match matchSingleAnswer = Regex.Match(input, @"\[(question|calc|comment)\(([0-9]{5}|[0-9]{4}|[0-9]{3}|[0-9]{2}|[0-9]{1})\)]",
                        RegexOptions.IgnoreCase);
                    //SINGLE VARIABLE
                    Match matchSingleVariable = Regex.Match(input, @"\[(variable)\(([0-9]{5}|[0-9]{4}|[0-9]{3}|[0-9]{2}|[0-9]{1})\)]",
                        RegexOptions.IgnoreCase);
                    //URL
                    Match matchUrl = Regex.Match(input, @"\[url",
                        RegexOptions.IgnoreCase);
                    //GEO DATA
                    Match matchGeo = Regex.Match(input, @"\[variable\(""STANDARD_",
                        RegexOptions.IgnoreCase);
                    //VARIABLES SHOWN
                    Match matchVariables = Regex.Match(input, @"\[variable",
                        RegexOptions.IgnoreCase);
                    //[question(1), option(\"1
                    //[question(11), option(\"2
                    //[question(111), option(\"1
                    //[question(1234), option(\"1
                    //[question(12345), option(\"1
                    ////////////////////////////////////////////
                    ////////The \ values are being removed.
                    ////////////////////////////////////////////
                    //OPTIONAL ANSWERS
                    string myReg = @"\[(question|url|variable|calc|comment)\(([0-9]{5}|[0-9]{4}|[0-9]{3}|[0-9]{2}|[0-9]{1})\),\ option\(""[0-9]";
                    Match matchOption = Regex.Match(input, myReg,
                        RegexOptions.IgnoreCase);
                    //[question(1), option(1
                    //[question(11), option(2
                    //[question(111), option(1
                    //[question(1234), option(1
                    //[question(12345), option(1
                    //MULTIPLE CHOICE
                    Match matchMultiSelect = Regex.Match(input, @"\[question\(([0-9]{5}|[0-9]{4}|[0-9]{3}|[0-9]{2}|[0-9]{1})\),\ option\([0-9]",
                        RegexOptions.IgnoreCase);
                    //[question(1), option(0)
                    //[question(11), option(0)
                    //[question(111), option(0)
                    //[question(1234), option(0)
                    //[question(12345), option(0)
                    //HIDDEN
                    Match matchHiddenValue = Regex.Match(input, @"\[question\(([0-9]{5}|[0-9]{4}|[0-9]{3}|[0-9]{2}|[0-9]{1})\),\ option\(0\)",
                        RegexOptions.IgnoreCase);
                    if (matchSingleAnswer.Success)
                    {
                        int index = int.Parse(name.Substring(10, name.IndexOf(')') - 10));
                        SurveyQuestion sq = new SurveyQuestion();
                        sq.QuestionID = index;
                        sq.QuestionResponse = serializer.Deserialize<string>(reader);
                        value.SurveyQuestions.Add(sq);
                    }
                    else if (matchUrl.Success)
                    {
                        string urlName = name.Substring(6, name.Length - 9);
                        SurveyUrl su = new SurveyUrl();
                        su.Name = urlName;
                        su.Value = serializer.Deserialize<string>(reader);
                        value.SurveyUrls.Add(su);
                    }
                    else if (matchGeo.Success)
                    {
                        string geoName = name.Substring(11, name.Length - 14);
                        SurveyGeoData sgd = new SurveyGeoData();
                        sgd.Name = geoName;
                        sgd.Value = serializer.Deserialize<string>(reader);
                        value.SurveyGeoDatas.Add(sgd);
                    }
                    else if (matchSingleVariable.Success)
                    {
                        int index = int.Parse(name.Substring(10, name.IndexOf(')') - 10));
                        SurveyVariable sv = new SurveyVariable();
                        sv.SurveyVariableID = index;
                        sv.Value = serializer.Deserialize<string>(reader);
                        value.SurveyVariables.Add(sv);
                    }
                    else if (matchVariables.Success)
                    {
                        string varName = name.Substring(11, name.Length - 14);
                        SurveyVariableShown svs = new SurveyVariableShown();
                        svs.Name = varName;
                        svs.Value = serializer.Deserialize<string>(reader);
                        value.SurveyVariableShowns.Add(svs);
                    }
                    else if (matchHiddenValue.Success)
                    {
                        int index = int.Parse(name.Substring(10, name.IndexOf(')') - 10));
                        SurveyQuestionHidden sqh = new SurveyQuestionHidden();
                        sqh.QuestionID = index;
                        sqh.QuestionResponse = serializer.Deserialize<string>(reader);
                        value.SurveyQuestionHiddens.Add(sqh);
                    }
                    else if (matchMultiSelect.Success)
                    {
                        //Multiple choice question selections
                        string[] nameArray = name.Split(')');
                        string questionPart = nameArray[0];
                        string optionPart = nameArray[1];
                        int index = int.Parse(questionPart.Substring(10, questionPart.Length - 10));
                        int indexSub = int.Parse(optionPart.Substring(9, optionPart.Length - 9));
                        SurveyQuestionMulti sqm = new SurveyQuestionMulti();
                        sqm.OptionID = indexSub;
                        sqm.QuestionID = index;
                        sqm.QuestionResponse = serializer.Deserialize<string>(reader);
                        value.SurveyQuestionMulties.Add(sqm);
                        //NEED TO ADD A BASE QUESTION TO POINT TO ALL THE MULTI
                        //SurveyQuestion sq = new SurveyQuestion();
                        //sq.QuestionID = sqm.QuestionID;
                        //sq.QuestionResponse = "";
                        //value.SurveyQuestions.Add(sq);
                    }
                    else if (matchOption.Success)
                    {
                        //Optional text value for a given question
                        string[] nameArray = name.Split(')');
                        string questionPart = nameArray[0];
                        string optionPart = nameArray[1];
                        int index = int.Parse(questionPart.Substring(10, questionPart.Length - 10));
                        int indexSub = int.Parse(optionPart.Substring(10, 5));
                        SurveyQuestionOption sqo = new SurveyQuestionOption();
                        sqo.OptionID = indexSub;
                        sqo.QuestionID = index;
                        sqo.QuestionResponse = serializer.Deserialize<string>(reader);
                        value.SurveyQuestionOptions.Add(sqo);
                    }
                    else
                    {
                        var property = typeof(Data).GetProperty(name);
                        if (property != null)
                            property.SetValue(value, serializer.Deserialize(reader, property.PropertyType), null);
                    }
                    // Skip the , or } if we are at the end
                    reader.Read();
                }
                return value;
            }
