        private string CreateCommaDelimitedList(IList ilist)
        {
            IList<Item> list = ilist as IList<Item>;
            if (list == null)
                return null;
            // build a comma-delimited list of names to display in a control
            List<string> names = list.Select(it => it.Name).ToList();
            StringBuilder sb = new StringBuilder();
            bool comma = false;
            foreach (var name in names)
            {
                if (comma)
                    sb.Append(", ");
                else
                    comma = true;
                sb.Append(name);
            }
            return sb.ToString();
        }
