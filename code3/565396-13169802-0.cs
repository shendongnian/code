    using System.Text;
    using System.Linq;
    static string GetNum(string input)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (input[i] < 48 || input[i] > 57)
                break;
            sb.Append(input[i]);
        }
        return String.Concat(sb.ToString().ToCharArray().Reverse());
    }
