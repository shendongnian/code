            private static void runOnThread(Control x, Action logic)
        {
            if (x.InvokeRequired)
            {
                x.Invoke(logic);
            }
            else
            {
                logic();
            }
        }
