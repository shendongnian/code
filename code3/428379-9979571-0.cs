        public HttpResponseMessage<SensorUpdate> Post(int id)
        {
            SensorUpdate su = new SensorUpdate();
            su.Id = 12345;            
            su.Username = "SensorUpdateUsername";
            su.Text = "SensorUpdateText";
            su.Published = DateTime.Now;
            
            HttpResponseMessage<SensorUpdate> response = new HttpResponseMessage<SensorUpdate>(su, 
                        new MediaTypeHeaderValue("application/json"));
            return response;
        }
