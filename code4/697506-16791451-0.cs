            private void SetDisplayMode(DisplayMode mode)
            {
                var proc = new Process();
                proc.StartInfo.FileName = "DisplaySwitch.exe";
                switch (mode)
                {
                    case DisplayMode.External:
                        proc.StartInfo.Arguments = "/external";
                        break;
                    case DisplayMode.Internal:
                        proc.StartInfo.Arguments = "/internal";
                        break;
                    case DisplayMode.Extend:
                        proc.StartInfo.Arguments = "/extend";
                        break;
                    case DisplayMode.Duplicate:
                        proc.StartInfo.Arguments = "/clone";
                        break;
                }
                proc.Start();
            }
            enum DisplayMode
            {
                Internal,
                External,
                Extend,
                Duplicate
            }
