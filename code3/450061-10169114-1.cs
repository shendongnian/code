    Foo foo;
    using(var source = ...) {
        foo = Serializer.Deserialize<Foo>(source);
    }
    string xml;
    using(var sw = new StringWriter()) {
        var ser = new Serializer(typeof(Foo));
        ser.Serialize(sw, foo);
        xml = sw.ToString();
    }
