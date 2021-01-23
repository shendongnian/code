        enum Gender{
            male,
            female
        }
        
    StringBuilder sb = new StringBuilder()
        Parallel.ForEach((Gender[])Enum.GetValues(typeof(Gender)), gender=>
                    {
                        sb.Append(gender.ToString()).Append(" ")
                    });
