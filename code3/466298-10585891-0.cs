    public class EcranJeu : AffichageJeu
    {
        private IKystObject décor;  // for example
        public EcranJeu(string choixecran)
        {
            if (choixecran == "0")
            {
                décor = new KystExtract();
            }
            if (choixecran == "1")
            {
                décor = new KystExtraction();
            }
        }
    
        public override void  LoadContent()
        {
            décor.LoadContent(content);
        }
    }
    // Common interface for classes requiring shared behavior
    public interface IKystObject
    {
        public override void  LoadContent();
    }
    // Both classes implement your common interface
    public class KystExtract : IKrystObject
    {
        ...
    }
    // Both classes implement your common interface
    public class KystExtraction : IKrystObject
    {
        ...
    }
