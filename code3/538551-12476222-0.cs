    protected void SwitchToWindow(string name)
        {
            foreach (string item in _driver.WindowHandles)
            {
                if (_driver.SwitchTo().Window(item).Title.Contains(name))
                {
                    _driver.SwitchTo().Window(item);
                    break;
                }
            }
        }
