    abstract class GameObject
    {
        abstract bool CheckCollision (GameObject other);
        abstract bool CheckCollision (Sphere other);
        abstract bool CheckCollision (Cube other);
        abstract bool CheckCollision (Plane other);
    }
    
    class Sphere : GameObject
    {
        override bool CheckCollision (GameObject other) { return other.CheckCollision(this); }
        override bool CheckCollision (Sphere other) { /* ... implementation ... */ }
        override bool CheckCollision (Cube other) { /* ... implementation ... */ }
        override bool CheckCollision (Plane other) { /* ... implementation ... */ }
    }
    
    class Cube : GameObject
    {
        override bool CheckCollision (GameObject other) { return other.CheckCollision(this); }
        override bool CheckCollision (Sphere other) { /* ... implementation ... */ }
        override bool CheckCollision (Cube other) { /* ... implementation ... */ }
        override bool CheckCollision (Plane other) { /* ... implementation ... */ }
    }
    
    class Plane : GameObject
    {
        override bool CheckCollision (GameObject other) { return other.CheckCollision(this); }
        override bool CheckCollision (Sphere other) { /* ... implementation ... */ }
        override bool CheckCollision (Cube other) { /* ... implementation ... */ }
        override bool CheckCollision (Plane other) { /* ... implementation ... */ }
    }
