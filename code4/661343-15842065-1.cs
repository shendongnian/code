    public void OnDerserilization(object sender)
    {
      PointProfiles = new Dictionary<Tuple<int, int>, IPointTrainingSet>();
      
      for (int i = 0; i < i1.Length; i++)
         PointProfiles.Add(new Tuple<int, int>(i1[i], i2[i]), ipts[i]);
    }
