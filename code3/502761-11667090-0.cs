     class FirefoxDriverEx : FirefoxDriver {
            public Process GetFirefoxProcess() {
                var fi = typeof(FirefoxBinary).GetField("process", BindingFlags.NonPublic | BindingFlags.Instance);
                return fi.GetValue(this.Binary) as Process;
            }
        }
