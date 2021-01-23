    ... // e.g Mouse Down
    originalX = Mouse.X; // Or whatever static X value you have.
        
    ... // e.g Mouse Move
    // Y is dynamically updated while X remains static
    YourObject.Location = new Point(originalX, Mouse.Y);
