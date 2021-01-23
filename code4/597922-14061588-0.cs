    byte[] bytes = new byte[] { 0x00, 0x00, 0x11, 0x01, 0x83, 0x50, 0x00, 0x0B, 0xF8 };
    var ints = bytes.Select((b, i) => new { b, i })
                    .GroupBy(x => x.i / 3)
                    .Select(g => BitConverter.ToInt32(
                                    new byte[] { 0 }.Concat(g.Select(x => x.b))
                                                             .Reverse()
                                                             .ToArray(),
                                    0))
                    .ToArray();
