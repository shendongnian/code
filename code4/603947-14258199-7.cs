    class InformationGartherer {
        private Thread garthererThread;
        public InformationGartherer() {
            garthererThread = new Thread(new ThreadStart(GartherData));
        }
        private void GartherData() {
            while (true) {
                List<float> gartheredInfo = new List<float>();
                //Do your garthering and parsing here (and put it in the gartheredInfo variable)
                InformationHolder.Instance().graphData = gartheredInfo;
                graphForm.Invoke(new MethodInvoker( //you need to have a reference to the form
                       delegate {
                           graphForm.Invalidate(); //or another method that redraws the graph
                       }));
                Thread.Sleep(100); //Time in ms
            }
        }
    }
