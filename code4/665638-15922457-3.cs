    Vector3 gravity = new Vector3(0, -9.8f, 0);
    private void UpdateParticles(float time)
    {
        for (int i = 0; i < particles.Length; ++i)
        {
            particles[i].velocity += gravity * time;
            particles[i].position += particles[i].velocity * time;
        }
    }
