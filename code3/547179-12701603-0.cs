    [TestMethod]
    public void RendererRendersEachWidgetByCallingBeginRenderThenEndRender()
    {
        // Mocks/Stubs
		  var orderedResultList = new List<string>();
        var space = MockRepository.GenerateStub<ISpace>();
		  space.Stub(s => s.BeginRender(Arg<IWidget>.Is.Anything))
				.WhenCalled(x => orderedResultList.Add("Begin Render " + ((IWidget)x.Arguments[0]).Id));
		  space.Stub(s => s.EndRender(Arg<IWidget>.Is.Anything))
				.WhenCalled(x => orderedResultList.Add("End Render " + ((IWidget)x.Arguments[0]).Id));
        var world = MockRepository.GenerateStub<IWorld>();
        var widget1 = MockRepository.GenerateStub<IWidget>();
		  widget1.Stub(w => w.Id).Return("widget1"); // assuming no public setter for this property
        var widget2 = MockRepository.GenerateStub<IWidget>();
		  widget2.Stub(w => w.Id).Return("widget2"); // assuming no public setter for this property
        var widgetList = new List<IWidget>{ widget1, widget2 };
		  world.Stub(w => w.Widgets).Return(widgetList);
        // Object under test
        IRenderer target = new Renderer(world, space);
        target.Render();
        // verify BeginRender is called
		  space.AssertWasCalled(s => s.BeginRender(Arg<IWidget>.Is.Same(widget1)));
		  space.AssertWasCalled(s => s.BeginRender(Arg<IWidget>.Is.Same(widget2)));
        // verify EndRender is called
		  space.AssertWasCalled(s => s.EndRender(Arg<IWidget>.Is.Same(widget1)));
		  space.AssertWasCalled(s => s.EndRender(Arg<IWidget>.Is.Same(widget2)));
        // verify BeginRender is called before EndRender
        var orderedResults = orderedResultList.Select((s, i) => Tuple.Create(i, s));
        Assert.IsTrue(
            (orderedResults.Single(x => x.Item2 == "Begin Render " + widget1.Id).Item1) <
            (orderedResults.Single(x => x.Item2 == "End Render " + widget1.Id).Item1));
        Assert.IsTrue(
            (orderedResults.Single(x => x.Item2 == "Begin Render " + widget2.Id).Item1) <
            (orderedResults.Single(x => x.Item2 == "End Render " + widget2.Id).Item1));
    }
