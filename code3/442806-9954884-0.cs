            string detail = "Victoria Adelaide Mary/Wettin/";
            string name = "";
            string[] detailArray = detail.Replace('/', ' ').Split(' ');
            foreach (string s in detailArray)
            {
                name += s + " ";
            }
            // trim last space character
            name = name.TrimEnd(' ');
