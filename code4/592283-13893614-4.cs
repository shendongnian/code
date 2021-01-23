	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	namespace CardDeck
	{
		public partial class CardDeckForm : Form
		{
			private CardDeck _cardDeck = null;
			public CardDeckForm()
			{
				InitializeComponent();
				LoadCards();
				ShowImage();
			}
			private void LoadCards()
			{
				using (var source = new Bitmap(@"AllCards.png"))
				{
					var cards = new CardCropper(source, rowCount: 4, cardsPerRow: 13).CropCards();
					_cardDeck = new CardDeck(cards, rowCount: 4, cardsPerRow : 13);
				}
			}
			private void NextButton_Click(object sender, EventArgs e)
			{
				_cardDeck.Index++;
				ShowImage();
			}
			private void PreviousButton_Click(object sender, EventArgs e)
			{
				_cardDeck.Index--;
				ShowImage();
			}
			private void ShowImage()
			{
				this.pictureBox1.Image = _cardDeck.GetCardFromIndex();
			}
		}
	}
