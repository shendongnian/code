class TestPays
{
    public static <b>List&lt;Pays&gt;</b> LireRemplirPays() { //...blabla
        return uneListe; // Cast here if necessary
    }
    static void Main(string[] args) {
        <b>List&lt;Pays&gt;</b> paysList = LireRemplirPays();
        paysList.Sort();          
    }
}
