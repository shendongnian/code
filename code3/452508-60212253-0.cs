    using System.Linq;
    const int pointsCount = 100;
    point[] array = Enumerable.Range(0, pointsCount)
        .Select(_ => new point())
        .ToArray()
