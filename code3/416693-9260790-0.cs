    private delegate void updateDelegate(string p1, string p2);
    private updateDelegate DoSomething;
    private void MakeItHappen(string InputA, string InputB)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(DoSomething, InputA, InputB);
        }
        else
        {
            //Do stuff
        }
    }
