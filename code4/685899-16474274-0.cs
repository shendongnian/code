            DateTime result;
            var stt = "5/10/2013 002704";
            string[] formats = { "d/M/yyyy HHmmss", "dd/MM/yyyy HHmmss", "d/MM/yyyy HHmmss", "dd/M/yyyy HHmmss" };
            if (DateTime.TryParseExact(stt, formats, null, System.Globalization.DateTimeStyles.None, out result))
            {
                // ... do something with "result" in here ...
                Console.WriteLine(result.ToString());
            }
            else
            {
                // ... parse failed ...
            }
