    class Ctupple
    {
        List<Tuple<int, string, DateTime>> tupple_list = new List<Tuple<int, string, DateTime>>();
        public void create_tupple()
        {
            for (int i = 0; i < 20; i++)
            {
                tupple_list.Add(new Tuple<int, string, DateTime>(i, "Dump", DateTime.Now));
            }
            StringBuilder sb = new StringBuilder();
            foreach (var v in tupple_list)
            {
                sb.Append(v.Item1);
                sb.Append("    ");
                sb.Append(v.Item2);
                sb.Append("    ");
                sb.Append(v.Item3);
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb.ToString());
            int j = 0;
        }
        public void update_tupple()
        {
            var vt = tupple_list.Find(s => s.Item1 == 10);
            int index = tupple_list.IndexOf(vt);
            vt = new Tuple<int, string, DateTime>(vt.Item1, "New Value" , vt.Item3);
            tupple_list.RemoveAt(index);
            tupple_list.Insert(index,vt);
            StringBuilder sb = new StringBuilder();
            foreach (var v in tupple_list)
            {
                sb.Append(v.Item1);
                sb.Append("    ");
                sb.Append(v.Item2);
                sb.Append("    ");
                sb.Append(v.Item3);
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb.ToString());
        }
    }
