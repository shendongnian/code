    public void setPg1InAnotherThread(Int32 val)
        {
            new Func<Int32>(setPbValue).BeginInvoke(new AsyncCallback(setPbValueCallback), null);
        }
        private Int32 setPbValue()
        {
            Int32 result = recCount;
            return result;
        }
        private void setPbValueCallback(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;
            Func<Int32> del = (Func<Int32>)result.AsyncDelegate;
            try
            {
                Int32 pbValue = del.EndInvoke(ar);
                if (pbValue != 0)
                {
                    Form1 frm1 = (Form1)findOpenForm(typeof(Form1));
                    if (frm1 != null)
                    {
                        frm1.setPbValue(pbValue);
                    }
                }
            }
            catch { }
        }
