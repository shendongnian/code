    public partial class GameWindow : Form
    {
        public void buttonInventory_Click(object sender, EventArgs e)
        {
            Basic.HP = Basic.HP++;
            updateValues();
        }
        public void updateValues()
        {
            hp.text = HealthInteger;
            basic.text = BasicInteger;
        }
    }
