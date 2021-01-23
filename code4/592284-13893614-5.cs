    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    namespace CardDeck
    {
        public class CardCropper
        {
            private Bitmap _source;
            private int _cardsPerRow;
            private int _rowCount;
            private int _cardCount;
            private int _cardWidth;
            private int _cardHeight;
            public CardCropper(Bitmap source, int rowCount, int cardsPerRow)
            {
                _source = source;
                _cardsPerRow = cardsPerRow;
                _rowCount = rowCount;
                _cardCount = _cardsPerRow * _rowCount;
                _cardWidth = source.Width / _cardsPerRow;
                _cardHeight = source.Height / _rowCount;
            }
            public Bitmap[,] CropCards()
            {
                var cards = new Bitmap[_rowCount, _cardsPerRow];
                for (int y = 0; y < _rowCount; y++)
                {
                    for (int x = 0; x < _cardsPerRow; x++)
                    {
                        cards[y, x] = CropCard(x, y);
                    }
                }
                return cards;
            }
            private Bitmap CropCard(int x, int y)
            {
                var rect = new Rectangle(x * _cardWidth, y * _cardHeight, _cardWidth, _cardHeight);
                return _source.Clone(rect, _source.PixelFormat);
            }
        }
        public class CardDeck
        {
            private int _limit;
            private int _cardsPerRow;
            private int _index = 0;
            private Bitmap[,] _cards;
        
            public int Index
            {
                get
                {
                    CheckLimits();
                    return _index;
                }
                set
                {
                    _index = value;
                    CheckLimits();
                }
            }
            public CardDeck(Bitmap[,] cards, int rowCount, int cardsPerRow)
            {
                _cards = cards;
                _limit = rowCount * cardsPerRow;
                _cardsPerRow = cardsPerRow;            
            }
            public Image GetCardFromIndex()
            {
                var point = GetPointFromIndex();
                return _cards[point.Y, point.X];
            }
            private void CheckLimits()
            {
                if (_index >= _limit)
                {
                    _index = 0;
                }
                if (_index < 0)
                {
                    _index = _limit - 1;
                }
            }
            private Point GetPointFromIndex()
            {
                int x = this.Index % _cardsPerRow;
                int y = this.Index / _cardsPerRow;
                return new Point(x, y);
            }
        }
    }
