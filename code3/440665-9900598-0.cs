    // using ID as the key
    private readonly Dictionary<int, TextBox> mPlayerTextBoxes;
    // ...or using object as the key
    private readonly Dictionary<Player, TextBox> mPlayerTextBoxes;
    // in form constructor, after InitializeComponent call:
    // using ID as the key
    mPlayerTextBoxes = new Dictionary<int, TextBox>
    {
       { player1.ID, textbox1 },
       { player2.ID, textbox2 },
       { player3.ID, textbox3 }
    };
    // using object as the key
    mPlayerTextBoxes = new Dictionary<Player, TextBox>
    {
       { player1, textbox1 },
       { player2, textbox2 },
       { player3, textbox3 }
    };
    // then when you want a textbox, given a player:
    // using ID    
    TextBox textBox = mPlayerTextBoxes[player.ID];
    // using object
    TextBox textBox = mPlayerTextBoxes[player];
