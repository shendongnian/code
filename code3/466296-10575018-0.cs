    public class EcranJeu : AffichageJeu
    {
        private KystExtract décor;
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
