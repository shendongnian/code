        static Bitmap[] CreateDeckImages() {
            var deck = new Bitmap[52];
            using (var images = Properties.Resources.CardFaces) {
                for (int cardnum = 0; cardnum < deck.Length; ++cardnum) {
                    deck[cardnum] = GetCardImage(images, cardnum);
                }
            }
            return deck;
        }
