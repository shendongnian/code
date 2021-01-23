            var json = @"
                        {
                            'APITicket': {
                                'location': 'SOMEVALUE',
                                'ticket': 'SOMEVALUE'
                            }
                        }";
            //Parse the JSON:
            var jObject = JObject.Parse(json);
            //Select the nested property (we expect only one):
            var jProperty = (JProperty)jObject.Children().Single();
            //Deserialize it's value to a TicketModel instance:
            var ticket = jProperty.Value.ToObject<TicketModel>();
