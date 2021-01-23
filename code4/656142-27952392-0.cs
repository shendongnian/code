            static string ReverseIntact(char[] input)
            {
                //char[] input = "dog world car life".ToCharArray();
                for (int i = 0; i < input.Length / 2; i++)
                {//reverse the expression
                    char tmp = input[i];
                    input[i] = input[input.Length - i - 1];
                    input[input.Length - i - 1] = tmp;
                }
                for (int j = 0, start = 0, end = 0; j <= input.Length; j++)
                {
                    if (j == input.Length || input[j] == ' ')
                    {
                        end = j - 1;
                        for (; start < end; )
                        {
                            char tmp = input[start];
                            input[start] = input[end];
                            input[end] = tmp;
                            start++;
                            end--;
                        }
                        start = j + 1;
                    }
                }
                return new string(input);
            }
