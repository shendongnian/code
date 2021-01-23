    private void btnStart_Click(object sender, EventArgs e)
        {
            if(capture==null){
                try
            {                    
                capture = new Capture();
            }
            catch(NullReferenceException ex){
                MessageBox.Show(ex.Message);
            }
        }
        if(capture!=null){
            if (captureInProgress)
            {
                btnStart.Text = "!Start";
                capture.Stop(); //you miss this
                Application.Idle -= ProcessFrame;
            }
            else {
                btnStart.Text = "Stop";
                capture.Start(); //you miss this
                Application.Idle += ProcessFrame;
            }
        }
        captureInProgress = !captureInProgress;
    }
