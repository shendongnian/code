    public class MyInterfaceInfoView
    {
        public IMyInterfaceInfo[] Infos { get; set; }
        
        public MyInterfaceInfoView(IDictionary<string, object> aDict)
        {
            Type[] p1 = aDict["SomeProperty1"] as Type[];
            double[] p2 = aDict["SomeProperty2"] as double[];
            string[] p3 = aDict["SomeProperty3"] as string[];
            Infos = new ExportMyInterfaceAttribute[p1.Length];
            for (int i = 0; i < Infos.Length; i++)
                Infos[i] = new ExportMyInterfaceAttribute(p1[i], p2[i], p3[i]);
        }
    }
