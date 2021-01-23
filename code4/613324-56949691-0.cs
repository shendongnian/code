csharp
public class RandomIntGenerator
{
    public Random a = new Random();
    private List<int> _validNumbers;
    private RandomIntGenerator(int desiredAmount, int start = 0)
    {
        _validNumbers = new List<int>();
        for (int i = 0; i < desiredAmount; i++)
            _validNumbers.Add(i + start);
    }
    private int GetRandomInt()
    {
        if (_validNumbers.Count == 0)
        {
            //you could throw an exception here
            return -1;
        }
        else
        {
            var nextIndex = a.Next(0, _validNumbers.Count - 1);
            var number    = _validNumbers[nextIndex];
            _validNumbers.RemoveAt(nextIndex);
            return number;
        }
    }
}
