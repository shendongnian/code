       public List<Expected_and_Risk> ExpectValue(Expected_and_Risk abc)
       {
            int count = abc.Forecast.Count();
            List<Expected_and_Risk> list = new List<Expected_and_Risk>();
            Result.Initialize(count); 
            for (int i = 0 ; i < count ; i++)
            {
                Expected_and_Risk Result = new Expected_and_Risk();
                Result.Name[i] = abc.Name[i];
                Result.Prop[i] = abc.Prop[i];
                Result.Forecast[i] = abc.Forecast[i];
                Result.AxB[i] = abc.Prop[i] * abc.Forecast[i];
            
                decimal a = Result.AxB[i];
                decimal sumAxB =+ a;
                double temp = (double)(a * a) ;
                Result.PowAxB[i] = (decimal)(temp);
                list.Add(Result);
        }
        return list; 
    }
 
