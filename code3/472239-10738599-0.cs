            this.Enabled = false;
            var prc = System.Diagnostics.Process.Start("notepad.exe");
            prc.EnableRaisingEvents = true;
            prc.SynchronizingObject = this;
            prc.Exited += delegate { 
                this.Enabled = true;
                this.Activate();
            };
