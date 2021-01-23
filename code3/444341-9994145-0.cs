            Color a = Color.Red;            
            Color b = Color.FromArgb(a.A, a.R, a.G, a.B);
            
            string name1 = a.Name; //name is Red
            string name2 = b.Name; //name is ffff0000
