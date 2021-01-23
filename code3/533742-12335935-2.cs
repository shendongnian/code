    public class MyAppManager
    {
        private static readonly Soldier _soldier = new Solider();
        public static Soldier SoldierInstance
        {
            get { return _soldier; }
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        MyAppManager.SoldierInstnace.surname = textbox1.text;
    }
