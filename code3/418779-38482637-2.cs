            string msgErro = "";
            Exception exception = ex;
            do
            {
                if (exception.InnerException != null)
                    msgErro += exception.InnerException.Message;
                else
                    msgErro += exception.Message;
                msgErro += System.Environment.NewLine;
                exception = exception.InnerException;
            }
            while (exception.InnerException != null);
            return msgErro;
