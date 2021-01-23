            var stringResult = await productSearchDataService.LaunchSearchAsync(name, label); // Sends HttpWebRequest
            if (String.IsNullOrEmpty(stringResult )) { return; }     // TODO: notify no internet
            var status = (int)JObject.Parse(stringResult)["status"];            
            if (status != 100) { return; }            // TODO: notify some shit happened
            try
            {
                private var parsedResult = await TaskEx.Run(() => JsonConvert.DeserializeObject<NormalAnswerPoco>(stringResult));
            ***
            }
