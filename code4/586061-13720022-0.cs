        // perfectly fine using polymorphism; no Ifs' no casting, OOP at its best ;-)
        o.foo();
        var dca = o as DC_A;
        if (dca != null)
        {
            doX(dca);
        }
        var dcb = o as DC_B;
        if (dcb != null)
        {
            doY(dcb);
        }
