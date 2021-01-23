            var random = new Random((int) DateTime.Now.Ticks);
            try
            {
                var result = new byte[length];
                for (var index = 0; index < length; index++)
                {
                    result[index] = (byte) random.Next(33, 126);
                }
                return System.Text.Encoding.ASCII.GetString(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
