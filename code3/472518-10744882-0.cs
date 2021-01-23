		Fixture fix1 = FixtureFactory.CreateCircle(_world, 0.5f, 1, new Vector2(-5, 5));
		fix1.Body.BodyType = BodyType.Dynamic;
		
		Fixture fix2 = FixtureFactory.CreateCircle(_world, 0.5f, 1, new Vector2(5, 5));
		fix2.Body.BodyType = BodyType.Dynamic;
		
		JointFactory.CreateSliderJoint(_world, fix1.Body, fix2.Body, Vector2.Zero, Vector2.Zero, 10, 15);
