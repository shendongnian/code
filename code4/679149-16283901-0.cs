    using System.Linq;
    {... other usings and namespace/type declarations ...}
            string string1 = "Rawr";
            string string2 = "Rawr2";
            string string3 = "Rawr3";
            mobPartLabel.Text = String.Format(
                "String 1: {0} \nString 2: {1} \nString 3: {2}",
                   (string1.Take(20)),
                   (string2.Take(20)),
                   (string3.Take(20));
