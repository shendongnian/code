        public static string GetExceptionMessage(Exception ex)
        {
            if (ex.InnerException == null)
            {
                return string.Concat(ex.Message, System.Environment.NewLine, ex.StackTrace);
            }
            else
            {
                // Retira a última mensagem da pilha que já foi retornada na recursividade anterior
                // (senão a última exceção - que não tem InnerException - vai cair no último else, retornando a mesma mensagem já retornada na passagem anterior)
                if (ex.InnerException.InnerException == null)
                    return ex.InnerException.Message;
                else
                    return string.Concat(string.Concat(ex.InnerException.Message, System.Environment.NewLine, ex.StackTrace), System.Environment.NewLine, GetExceptionMessage(ex.InnerException));
            }
        }
