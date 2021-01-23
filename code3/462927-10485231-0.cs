    public interface IDeck{
        // provide the methods and properties that Game requires from Deck
    }
    public class PokerDeck:IDeck{
        // ... etc
    }
    public class TravelCardsDeck:IDeck{
        // ... etc
    }
    // [Test]
    IDeck deck = new TravelCardsDeck();
    var game = new Game(deck);
    Assert.That(game.GetDeckSuitCount(),Is.EqualTo(4));
