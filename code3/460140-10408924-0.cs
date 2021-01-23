                var result = new Dictionary<string, string>();
    
                result.Add("00","14");
                result.Add("01", "14");
                result.Add("02", "14");
                result.Add("03", "14");
                result.Add("1F", "19");
                result.Add("04", "17");
                result.Add("05", "18");
    
                return result[id.Substring(2, 2)];
