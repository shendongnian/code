            public override bool TryGet<TOriginal>(string input, out TOriginal output)
            {
                T oTemp;
                bool res = _func(input, out oTemp);
                Nullable<TOriginal> n = oTemp as Nullable<TOriginal>;
                output = n.GetValueOrDefault();
                return res;
            }
