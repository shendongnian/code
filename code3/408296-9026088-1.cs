       public class ChartGenerator
    {
        public event ChartCreatedEventHandler ChartCreated;
        public string CreatePieChartUrl(int pHeight, int pWidth,
            string[] pSeries, string pTitle, int[] pData)
        {
            
            string st = String.Format(Misc.EnUk,
            @"http://chart.apis.google.com/chart?chs={0}x{1}&cht=p3&chd=t:", pWidth, pHeight);
            for (int i = 0; i < pData.Length; i++)
            {
                st += pData[i].ToString(Misc.EnUk) + ",";
            }
            st = st.TrimEnd(',');
            st += "&chdl=";
            for (int i = 0; i < pData.Length; i++)
            {
                st += pSeries[i].Replace(" ", "+") + "|";
            }
            st = st.TrimEnd('|');
            st += "&chtt=";
            st += pTitle.Replace(" ", "+") + "|";
            return st;
        }
        public void CreatePieChart(int pHeight, int pWidth,
            string[] pSeries, string pTitle, int[] pData)
        {
            string url = CreatePieChartUrl(pHeight, pWidth,
             pSeries, pTitle, pData);
            Thread th = new Thread(new ParameterizedThreadStart(CreateChartAsync));
            th.Start(url);
        }
        public string CreateBarChartUrl(int pHeight, int pWidth, int pMax,
            string pTitle, int[] pData1, int[] pData2)
        {
          string st = String.Format(Misc.EnUk,
            @"http://chart.apis.google.com/chart?chxr=0,0,{0}&chxt=y&chbh=a&chs={1}x{2}&cht=bvs&chco=4D89F9,C6D9FD&chds=0,{0},0,{0}&chd=t:", 
                pMax, pWidth, pHeight);
           
            for (int i = 0; i < pData1.Length; i++)
            {
                st += pData1[i].ToString(Misc.EnUk) + ",";
            }
            st = st.TrimEnd(',');
            st += "|";
            for (int i = 0; i < pData2.Length; i++)
            {
                st += pData2[i].ToString(Misc.EnUk) + ",";
            }
            st = st.TrimEnd(',');
            st += "&chtt=";
            st += pTitle.Replace(" ", "+");
            return st;
        }
        public void CreateBarChart(int pHeight, int pWidth,int pMax,
          string pTitle, int[] pData1,int[] pData2)
        {
            string url = CreateBarChartUrl(pHeight, pWidth, pMax,
            pTitle, pData1, pData2);
            Thread th = new Thread(new ParameterizedThreadStart(CreateChartAsync));
            th.Start(url);
        }
        private void CreateChartAsync(object pUrl)
        {
            string url = pUrl as string;
            try
            {
                if (url != null)
                {
                    using (Stream stream = GetPageContentStream(url, false))
                    {
                        Image img = Image.FromStream(stream);
                        if (img != null)
                        {
                            if (ChartCreated != null)
                            {
                                ChartCreated(this, new ChartCreatedEventArgs(img));
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Debug.Fail(err.Message);
            }
        }
        /// <summary>
        /// Gets the stream of the given url
        /// </summary>
        /// <param name="url">The url</param>
        /// <param name="file">Whether this is a web file stream or a HttpWebRequest</param>
        /// <returns></returns>
        public static Stream GetPageContentStream(string url, bool file)
        {
            try
            {
                WebRequest wreq;
                WebResponse wres;
                if (file)
                {
                    wreq = System.Net.FileWebRequest.Create(url);
                }
                else
                {
                    wreq = HttpWebRequest.Create(url);
                    HttpWebRequest httpwrqst = wreq as HttpWebRequest;
                    if (httpwrqst != null)
                    {
                        httpwrqst.AllowAutoRedirect = false;
                        httpwrqst.Timeout = 10000;
                    }
                }
                wres = wreq.GetResponse();
                return wres.GetResponseStream();
            }
            catch(Exception err)
            {
                Debug.Fail(err.Message);
                Logger.AppLogger.Instance.LogError("GetPageContentStream", err);
                return null;
            }
        }
    }
    public delegate void ChartCreatedEventHandler(object sender,ChartCreatedEventArgs e);
    [Serializable]
    public class ChartCreatedEventArgs : EventArgs
    {
        private readonly Image mImage;
        public ChartCreatedEventArgs()
        {
        }
        public ChartCreatedEventArgs(Image pImage)
        {
            mImage = pImage;
        }
        public Image Image
        {
            get
            {
                return mImage;
            }
        }
    }
