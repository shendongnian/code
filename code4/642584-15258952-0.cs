            // store all lines in a list
            // ...
            var list = new List<string> {"blah", "blah2", "and some more blah"};
            var list2 = new List<string>();
            var i = 1;
            foreach (var str in list)
            {
                list2.Add(string.Format("{0} {1}", i, str));
                i++;
            }
            // write contents of list2 back to wherever you want them visualized
