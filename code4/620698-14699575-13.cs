    private static void rethrow(){
        try{
            if (test) 
                throwIt(); // 15
            else 
                throwIt(); // 17
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
            throw; // 20
        }
    }
