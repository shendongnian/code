        static void Main(string[] args){
            try {
                try {
                    throw new Exception("test"); // 13
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                    throw ex;// 17
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
