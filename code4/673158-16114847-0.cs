    public class TheClassThatUseThePlayerObject
    {
        private Player thePlayer = new Player(int.Parse(StrBox.Text), int.Parse(DexBox.Text), int.Parse(IntBox.Text), int.Parse(PerBox.Text), int.Parse(HPBox.Text), int.Parse(SPBox.Text), int.Parse(MPBox.Text), int.Parse(EXPBox.Text), int.Parse(ARBox.Text), int.Parse(CTHBox.Text), int.Parse(GoldBox.Text), int.Parse(MeleeDMGBox.Text), int.Parse(MagicDMGBox.Text), int.Parse(StealthBox.Text), int.Parse(DetectBox.Text), int.Parse(LevelBox.Text));
    
        public void FirstMethod()
        {
            thePlayer.DoSomething();
        }
        public void SecondMethod()
        {
            thePlayer.DoSomethingElse();
        }
    }
