    public static int DiceSum4(IEnumerable<object> values)
    {
        var sum = 0;
        foreach (var item in values)
        {
            switch (item)
            {
                case 0:
                    break;
                case int val:
                    sum += val;
                    break;
                case IEnumerable<object> subList when subList.Any():
                    sum += DiceSum4(subList);
                    break;
                case IEnumerable<object> subList:
                    break;
                case null:
                    break;
                default:
                    throw new InvalidOperationException("unknown item type");
            }
        }
        return sum;
    }
