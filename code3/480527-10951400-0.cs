        private void CheckBox_1()
        {
            foreach (var checkbox in FindChildren<CheckBox>(container, c => c.Name.StartsWith("A")))
            {
                checkbox.Enabled = checkBox1.Checked == true ? true : false;
            }
        }
        public static IEnumerable<T> FindChildren<T>(Control parent, Func<T, bool> filter)
            where T : Control
        {
            var search = new Stack<Control>();
            search.Push(parent);
            while (search.Count > 0)
            {
                parent = search.Pop();
                foreach (Control child in parent.Controls)
                {
                    T typed = child as T;
                    if (typed != null && filter(typed))
                    {
                        yield return typed;
                        continue;
                    }
                    search.Push(child);
                }
            }
        }
