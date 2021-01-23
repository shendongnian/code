            if (!treeviewExplorer.UplevelBrowser)
            {
                // fix internal UplevelBrowser setting
                PropertyInfo p = treeviewExplorer.GetType().GetProperty("x754cb9503fcb8508", BindingFlags.NonPublic|BindingFlags.Instance);
                object x754cb9503fcb8508 = p.GetValue(treeviewExplorer, null);
                FieldInfo f = x754cb9503fcb8508.GetType().GetField("_b1ea521a985d430f", BindingFlags.NonPublic | BindingFlags.Instance);
                f.SetValue(x754cb9503fcb8508, true);
            }
