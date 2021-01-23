    for (int i = 1; i < 10; i++)
            {
                cardGui1 = new CardGui1(i);
                cardGui1.Location = new Point(10 + (i * 10), 10);
                panel1.Controls.Add(cardGui1);   
            }
    const j =10;
    cardGui2 = new cardGui2(j);
    cardGui12.Location = new Point(10 + (j * 10), 10);
    panel1.Controls.Add(cardGui2);
    cardGui2.BringToFront();
