    Process process = Process.GetCurrentProcess();
    var dupl = (Process.GetProcessesByName(process.ProcessName));
    if( dupl.Length > 1 && MessageBox.Show("Kill?", "Kill duplicates?", MessageBoxButtons.YesNo) == DialogResult.Yes ) {
        foreach( var p in dupl ) {
            if( p.Id != process.Id )
                p.Kill();
        }
    }
