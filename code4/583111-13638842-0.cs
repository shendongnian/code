        public partial class Form1 : Form
        {
            private Thread _worker;
            private delegate void SendErrorDelegate(string exceptionMessage);
            private delegate void SetCurrentStatus(string status);
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                     this._worker = new Thread(new ThreadStart(MyMethod));
                     this._worker.Start();
                }
                catch (Exception ex)
                {
                    HandleError(ex.Message);
                }
            }
            private void MyMethod()
            {
                //you can do work like crazy here, but any time you want to update UI from this method,
                //it should be done with a delegate method like:
                SetStatusLabel("this happened");
                //and
                SetStatusLabel("I just did something else");
            }
            private void SetStatusLabel(string status)
            {
               if (this.InvokeRequired)
               {
                    this.Invoke(new SetCurrentStatus(SetStatusLabel), status);
                    return;
               }
               this.lblStatusLable.Visible = true;
               this.lblStatusLabel.Text = status;
            }
            private void HandleError(string ex)
            {
                 if (this.InvokeRequired)
                 {
                    this.Invoke(new SendErrorDelegate(HandleError), ex);
                    return;
                 }
                 //update some UI element from delegate now. eg-
                 this.txtExceptionBox.Text = ex;                 
             }
        }      
