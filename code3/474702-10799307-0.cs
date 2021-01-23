            const string FMT = "yyyy-MM-dd HH:mm:ss.fffffff";
            DateTime now1 = DateTime.Now;
            string strDate = now1.ToString(FMT);
            DateTime now2 = DateTime.ParseExact(strDate, FMT, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
            Console.WriteLine(now1.ToBinary());
            Console.WriteLine(now2.ToBinary());
