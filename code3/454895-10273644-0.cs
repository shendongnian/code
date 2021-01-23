             for (int i = 0; i < cnt; i++)
             {
                 if (this._BackgroundWorker.CancellationPending)
                 {
                     e.Cancel = true;
                     return;
                 }
                 string argument = this.listView1.CheckedItems[i].Text;
                 this.DoSend(argument);
             }
         
 
   
   
